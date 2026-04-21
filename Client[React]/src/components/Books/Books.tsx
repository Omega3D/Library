import React, { Fragment, useEffect, useState } from "react";
import { Book } from "../../Models/BooksType";
import {
  List,
  ListItem,
  ListItemAvatar,
  Avatar,
  ListItemText,
} from "@mui/material";

type Props = {};
type BooksListProps = {
  books: Book[];
};
const booksUrl = "https://localhost:5001/api/Books/list";

const Books = (props: Props) => {
  const [books, setBooks] = useState<Book[]>([]);
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const response = await fetch(booksUrl);

        if (!response.ok) {
          throw new Error("Failed to fetch books!");
        }
        const data: Book[] = await response.json();
        setBooks(data);
      } catch (error: any) {
        console.log(error);
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };
    fetchBooks();
  }, []);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return <BooksList books={books} />;
};

function BooksList({ books }: BooksListProps) {
  return (
    <Fragment>
      <h1>Books</h1>
      <List sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}>
        {books.map((book) => (
          <ListItem key={book.id}>
            <ListItemAvatar>
              <Avatar src={book.imagePath} />
            </ListItemAvatar>

            <ListItemText
              primary={book.title}
              secondary={`${book.genre} • $${book.price}`}
            />
          </ListItem>
        ))}
      </List>
    </Fragment>
  );
}

export default Books;

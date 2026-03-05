export interface BookDetails{
    id: number;
    title: string;
    description: string;
    isbn: string;
    language: string,
    genre: string;
    type: string;
    publicationYear: number;
    price: number;
    quantity: number;
    imagePath?: string;
}
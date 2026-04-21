import { useState } from "react";
import { Fragment } from "react/jsx-runtime";

interface ListProps {
  items: {
    name: string;
    color: string;
  }[];
  headingName: string;
}

function ListGroup() {
  let items = [
    { name: "Apple", color: "Red" },
    { name: "Banana", color: "Yellow" },
    { name: "Lime", color: "Green" },
  ];

  let headingName = "Fruits";

  return ListGroupFragment({ items, headingName });
}

function ListGroupFragment({ items, headingName }: ListProps) {
  const [selectedIndex, setSelectedIndex] = useState<Number>(-1);

  if (items.length === 0)
    return (
      <>
        <h1>heading</h1>
        <p>No Elements Found</p>
      </>
    );
  else
    return (
      <Fragment>
        <h1>{headingName}</h1>
        <ul className="list-group list-group-flush">
          {items.map((item, index) => (
            <li
              onClick={() => setSelectedIndex(index)}
              className={
                selectedIndex === index
                  ? "list-group-item active"
                  : "list-group-item"
              }
              key={index}
            >
              {item.name}, {item.color}
            </li>
          ))}
        </ul>
      </Fragment>
    );
}

export default ListGroup;

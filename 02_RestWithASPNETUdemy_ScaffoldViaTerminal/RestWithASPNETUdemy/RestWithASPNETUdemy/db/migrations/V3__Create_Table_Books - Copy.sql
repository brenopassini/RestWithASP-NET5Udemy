CREATE TABLE books (
  id INT IDENTITY PRIMARY KEY,
  author text,
  launch_date datetime NOT NULL,
  price decimal(10,2) NOT NULL,
  title TEXT
  )
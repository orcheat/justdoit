CREATE TABLE Tasks_arc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    DueDate DATETIME NOT NULL,
    IsCompleted BIT NOT NULL,
    Priority NVARCHAR(50) NOT NULL,
    Category NVARCHAR(100) NOT NULL
);

CREATE TABLE Categories_arc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

select * from Categories_arc
select * from tasks_arc

ALTER TABLE Tasks_arc
ADD CategoryId INT;

ALTER TABLE Tasks_arc
ADD CONSTRAINT FK_Tasks_Category
FOREIGN KEY (CategoryId) REFERENCES Categories_arc(Id);

INSERT INTO Categories_arc VALUES('Work')

ALTER TABLE Tasks_arc
DROP COLUMN Category;

SELECT * FROM Categories_arc WHERE Id = 4

CREATE TABLE Comments_arc (
    CommentId INT PRIMARY KEY IDENTITY,
    TaskId INT NOT NULL,
    CommentText NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (TaskId) REFERENCES Tasks_arc(Id)
);

SELECT * FROM Comments_arc

CREATE TABLE Documents_arc (
    DocumentId INT IDENTITY(1,1) PRIMARY KEY,
    TaskId INT NOT NULL,
    DocumentPath NVARCHAR(MAX) NOT NULL,
    UploadedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (TaskId) REFERENCES Tasks_arc(Id)
);

SELECT * FROM Documents_arc


CREATE TABLE Users_arc (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(MAX) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

SELECT * FROM Users_arc
Update Users_arc 
SET Password='clientpassword'
WHERE Username='clientuser';


INSERT INTO Users_arc (Username, Password, Role)
VALUES ('admin', 'admin', 'Admin');

-- Rename column in a table
EXEC sp_rename 'Users_arc.PasswordHash', 'Password', 'COLUMN';


ALTER TABLE Tasks_arc
ADD UserId INT;

ALTER TABLE Tasks_arc
ADD CONSTRAINT FK_UserId FOREIGN KEY (UserId) REFERENCES Users_arc(Id);


SELECT t.Id, t.Title, t.DueDate, t.IsCompleted, t.Priority, t.CategoryId, c.Name AS CategoryName, t.UserId, u.Username
FROM Tasks_arc t
LEFT JOIN Categories_arc c ON t.CategoryId = 1
LEFT JOIN Users_arc u ON t.UserId = 1
WHERE t.Id = 5;

	SELECT emp_id, emp_name, salary,
   FORMAT(hire_date, 'MMMM dd, yyyy') AS hire_date
FROM employees;

ALTER TABLE Comments_arc
DROP CONSTRAINT FK__Comments___TaskI__3AA27A0F;

ALTER TABLE Comments_arc
ADD CONSTRAINT FK__Comments___TaskI__3AA27A0F
FOREIGN KEY (TaskId) REFERENCES Tasks_arc(Id) ON DELETE SET NULL;

SELECT Id, Username, Role FROM Users_arc;

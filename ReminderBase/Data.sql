USE ReminderBase
GO

SET LANGUAGE english;

--���������� ������� Category
INSERT INTO Categories
(CategoryName)
VALUES
('Meetings'),
('Family'),
('Home'),
('Business'),
('Rest')
GO

--���������� ������� Reminders

INSERT INTO Reminders
(Title, [Date], ReminderTime, [Image], CategoryId)
VALUES
('�������� ����������', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '..\Images\No-image-found.jpg', 3),
('��������� �����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 4),
('�������� �����', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '..\Images\No-image-found.jpg', 3),
('������� ������ �� �����', '2017-11-18', CAST('2017-11-17 12:30:00' as smalldatetime), '..\Images\No-image-found.jpg', 2),
('�������', '2017-11-10', CAST('2017-11-09 13:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 5),
('����� � ����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 5),
('����������� �����������', '2017-11-15', CAST('2017-11-14 13:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 4),
('������� � �������', '2017-11-20', CAST('2017-11-19 10:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 3),
('�������� ���� ��������', '2017-11-22', CAST('2017-11-21 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 2),
('��������� ��������� ����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 1)
GO

--���������� ������� Actions

INSERT INTO Actions
(ReminderId, ActionLine, [Action])
VALUES
(1,1,'��������� ��������'),
(1,2,'����� � ����� ����������'),
(2,1,'��������� ��������'),
(2,2,'����������� ���������'),
(2,3,'������� ����� �� ���������'),
(3,1,'������ ������')
GO

--���������� ������� Descriptions

INSERT INTO Descriptions
(ReminderId, Description)
VALUES
(1, '������ ������, ���������� ������ ������ ������� ��� ������� � �������� '),
(2, '������� ����� ��������� �� �������� ������� ����� ��������� ����������'),
(3, '��������� ����� ��������� � ������ � ��� � ������� ����������� �����'),
(4, '������ ����� ������� �� �������� �������'),
(5, '������� ����� ��������� �� �������� �������, ����� ����'),
(6, '����������� �� ����� ������� ���� ��������� � ��������'),
(7, '����������� ������� ������� ����� ��������� �� ������ ������'),
(8, '���������� ������ �������� � ������� ������'),
(9, '����� ������������ ������������� ���� � ����� ��������� �������'),
(10,'��������� �� ���������� ������, ��� ���� � ��� ����� ����� ������')

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

--���������� ������� Users
INSERT INTO Users
([Login], [Password], Email)
VALUES
('User', '6216F8A75FD5BB3D5F22B6F9958CDEDE3FC086C2', 'user@tut.by'), --password 111
('Editor', '1C6637A8F2E1F75E06FF9984894D6BD16A3A36A9', 'editor@tut.by'), --password 222
('Admin', '43814346E21444AAF4F70841BF7ED5AE93F55A9D', 'admin@tut.by') --password 333
GO

--���������� ������� Roles
INSERT INTO Roles
([Role])
VALUES
('User'),
('Edit'),
('Admin')
GO
--���������� ������� Users_Roles
INSERT INTO Users_Roles
(UserId, RoleId)
VALUES
(1,1),
(2,2),
(3,3)

--���������� ������� Reminders

INSERT INTO Reminders
(Title, [Date], ReminderTime, [Image], CategoryId, UserID)
VALUES
('�������� ����������', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '/Images/meeting.jpg', 3, 1),
('��������� �����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/family.jpg', 4, 1),
('�������� �����', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '/Images/home.jpg', 3, 1),
('������� ������ �� �����', '2017-11-18', CAST('2017-11-17 12:30:00' as smalldatetime), '/Images/business.jpg', 2, 1),
('�������', '2017-11-10', CAST('2017-11-09 13:00:00' as smalldatetime), '/Images/rest.jpg', 5, 1),
('����� � ����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/meeting.jpg', 5, 2),
('����������� �����������', '2017-11-15', CAST('2017-11-14 13:00:00' as smalldatetime), '/Images/family.jpg', 4, 2),
('������� � �������', '2017-11-20', CAST('2017-11-19 10:00:00' as smalldatetime), '/Images/home.jpg', 3, 2),
('�������� ���� ��������', '2017-11-22', CAST('2017-11-21 12:00:00' as smalldatetime), '/Images/business.jpg', 2, 2),
('��������� ��������� ����', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/rest.jpg', 1, 3)
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

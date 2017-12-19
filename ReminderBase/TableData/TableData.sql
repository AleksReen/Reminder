USE ReminderBase
GO

SET LANGUAGE english;

--заполнение таблицы Category
INSERT INTO Categories
(CategoryName)
VALUES
('Meetings'),
('Family'),
('Home'),
('Business'),
('Rest')
GO

--заполнение таблицы Users
INSERT INTO Users
([Login], [Password], Email)
VALUES
('User', '6216F8A75FD5BB3D5F22B6F9958CDEDE3FC086C2', 'user@tut.by'), --password 111
('Editor', '1C6637A8F2E1F75E06FF9984894D6BD16A3A36A9', 'editor@tut.by'), --password 222
('Admin', '43814346E21444AAF4F70841BF7ED5AE93F55A9D', 'admin@tut.by') --password 333
GO

--заполнение таблицы Roles
INSERT INTO Roles
([Role])
VALUES
('User'),
('Edit'),
('Admin')
GO
--заполнение таблицы Users_Roles
INSERT INTO Users_Roles
(UserId, RoleId)
VALUES
(1,1),
(2,2),
(3,3)

--заполнение таблицы Reminders

INSERT INTO Reminders
(Title, [Date], ReminderTime, [Image], CategoryId, UserID)
VALUES
('Починить автомобиль', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '/Images/meeting.jpg', 3, 1),
('Встретить босса', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/family.jpg', 4, 1),
('Починить полку', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '/Images/home.jpg', 3, 1),
('Забрать ребёнка из школы', '2017-11-18', CAST('2017-11-17 12:30:00' as smalldatetime), '/Images/business.jpg', 2, 1),
('Кемпинг', '2017-11-10', CAST('2017-11-09 13:00:00' as smalldatetime), '/Images/rest.jpg', 5, 1),
('Поход в горы', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/meeting.jpg', 5, 2),
('Оганизовать презинтацию', '2017-11-15', CAST('2017-11-14 13:00:00' as smalldatetime), '/Images/family.jpg', 4, 2),
('Сходить в магазин', '2017-11-20', CAST('2017-11-19 10:00:00' as smalldatetime), '/Images/home.jpg', 3, 2),
('Устроить жене свидание', '2017-11-22', CAST('2017-11-21 12:00:00' as smalldatetime), '/Images/business.jpg', 2, 2),
('Встретить родителей жены', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '/Images/rest.jpg', 1, 3)
GO

--заполнение таблицы Actions

INSERT INTO Actions
(ReminderId, ActionLine, [Action])
VALUES
(1,1,'Позвонить механику'),
(1,2,'Взять с собой инструмент'),
(2,1,'Позвонить серетарю'),
(2,2,'Подготовить документы'),
(2,3,'Вызвать такси до аэропорта'),
(3,1,'Купить гвозди')
GO

--заполнение таблицы Descriptions

INSERT INTO Descriptions
(ReminderId, Description)
VALUES
(1, 'Мастер Андрей, подготовит список нужных деталей для покупки в магазине '),
(2, 'Встреча будет проходить на открытом воздухе возле ресторана Митрополис'),
(3, 'Сломанная полка находится в гараже и для её ремонта понадобится дрель'),
(4, 'Ребёнок будет ожидать на школьном крыльце'),
(5, 'Кемпинг будем проводить на открытом воздухе, возле реки'),
(6, 'Восхождение на самую высокую гору совместно с друзьями'),
(7, 'Презинтация запуска проекта будет проходить во дворце Спорта'),
(8, 'Необходимо купить продукты и бытовые мелочи'),
(9, 'Будет организованн торжественный ужин в честь годовщины свадьбы'),
(10,'Приезжают на Московский вокзал, при себе у них будет много багажа')

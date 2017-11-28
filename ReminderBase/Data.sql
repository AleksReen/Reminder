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

--заполнение таблицы Reminders

INSERT INTO Reminders
(Title, [Date], ReminderTime, [Image], CategoryId)
VALUES
('Починить автомобиль', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '..\Images\No-image-found.jpg', 3),
('Встретить босса', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 4),
('Починить полку', '2017-11-20', CAST('2017-11-16 16:00:00'as smalldatetime), '..\Images\No-image-found.jpg', 3),
('Забрать ребёнка из школы', '2017-11-18', CAST('2017-11-17 12:30:00' as smalldatetime), '..\Images\No-image-found.jpg', 2),
('Кемпинг', '2017-11-10', CAST('2017-11-09 13:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 5),
('Поход в горы', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 5),
('Оганизовать презинтацию', '2017-11-15', CAST('2017-11-14 13:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 4),
('Сходить в магазин', '2017-11-20', CAST('2017-11-19 10:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 3),
('Устроить жене свидание', '2017-11-22', CAST('2017-11-21 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 2),
('Встретить родителей жены', '2017-11-15', CAST('2017-11-14 12:00:00' as smalldatetime), '..\Images\No-image-found.jpg', 1)
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

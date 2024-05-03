delete rota

INSERT INTO [dbo].[Rota] 
( [CreatedAt], [CreatedBy], [Destino], [IsDeleted], [ModifiedAt], [ModifiedBy], [Origem], [UniqueId], [Valor])
VALUES 
('2024-05-03T08:56:21.2048301-03:00', '1', 'BRC', CAST(0 AS bit), NULL, NULL, 'GRU', '7c7bb765-2e9c-437c-a784-2f9c99d151e0', 10.0),
('2024-05-03T08:56:21.2048322-03:00', '1', 'SCL', CAST(0 AS bit), NULL, NULL, 'BRC', '2d490c3f-2e33-4514-926f-fdb6057a838b', 5.0),
('2024-05-03T08:56:21.2048324-03:00', '1', 'CDG', CAST(0 AS bit), NULL, NULL, 'GRU', '871ad9ec-e8cf-4335-9847-091ffc3be2d2', 75.0),
('2024-05-03T08:56:21.2048326-03:00', '1', 'SCL', CAST(0 AS bit), NULL, NULL, 'GRU', 'de7411f4-e2a5-4832-886f-22866f4698a2', 20.0),
( '2024-05-03T08:56:21.2048328-03:00', '1', 'ORL', CAST(0 AS bit), NULL, NULL, 'GRU', '7abc463d-b4ff-4eb1-a077-bae6da7d461a', 56.0),
( '2024-05-03T08:56:21.2048329-03:00', '1', 'CDG', CAST(0 AS bit), NULL, NULL, 'ORL', 'fefa25b3-8784-4d5e-92a6-35a0550ed428', 5.0),
( '2024-05-03T08:56:21.2048331-03:00', '1', 'ORL', CAST(0 AS bit), NULL, NULL, 'SCL', '77699955-4f0f-4d23-9f8b-248232b02a75', 20.0);

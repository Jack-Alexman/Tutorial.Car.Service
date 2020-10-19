namespace Tutorial.Car.DAL.Queries
{
    public static class CarQueries
    {
        public static readonly string GetAll = $@"
            SELECT ID
                  ,[Description]
                  ,[CarModel]
                  ,[CompanyName]
                  ,[Count]
              FROM [Tutorial.Car.Dev].[dbo].[Channels]
        ";

        public static readonly string GetById = $@"
            SELECT [ID]
                  ,[Description]
                  ,[CarModel]
                  ,[CompanyName]
                  ,[Count]
              FROM [Tutorial.Car.Dev].[dbo].[Channels]
                WHERE [ID] = @Id
        ";

        public static readonly string Create = $@"
            insert into [Tutorial.Car.Dev].[dbo].[Channels]
		        ([Description], [CarModel], [Count])
		        Values (@Description, @CarModel, @Count)
        ";

        public static readonly string IsUniqueDescription = $@"
              SELECT CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM [Tutorial.Car.Dev].[dbo].[Channels]
			                where [Description] = @Description)
                    THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT)
                END
        ";

        public static readonly string IsUniqueModel = $@"
              SELECT CASE
                    WHEN EXISTS (
                        SELECT 1
                        FROM [Tutorial.Car.Dev].[dbo].[Channels]
			                where [CarModel] = @CarModel)
                    THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT)
                END
        ";

        public static readonly string Remove = $@"
              DELETE
                FROM [Tutorial.Car.Dev].[dbo].[Channels]
			                where [ID] = @Id
        ";

    }
}

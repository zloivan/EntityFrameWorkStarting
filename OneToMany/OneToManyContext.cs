namespace OneToMany
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OneToManyContext : DbContext
    {
        // Контекст настроен для использования строки подключения "OneToManyContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "OneToMany.OneToManyContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "OneToManyContext" 
        // в файле конфигурации приложения.
        public OneToManyContext()
            : base("name=OneToManyContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.


        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
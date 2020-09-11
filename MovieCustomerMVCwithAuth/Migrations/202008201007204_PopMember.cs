namespace MovieCustomerMVCwithAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopMember : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Membershiptypes(" +
                "Signup,durationinmonths,Discountrate) values(0,0,0)");
            Sql("insert into Membershiptypes(" +
              "signup,durationinmonths,Discountrate) values(30,1,10)");
            Sql("insert into Membershiptypes(" +
              "signup,durationinmonths,Discountrate) values(90,3,15)");
            Sql("insert into Membershiptypes(" +
              "signup,durationinmonths,Discountrate) values(300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}

﻿namespace ExamReg.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToTimeSpan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.lichthi", "GioBatDau", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.lichthi", "GioKetThuc", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.lichthi", "GioKetThuc", c => c.String(maxLength: 20));
            AlterColumn("dbo.lichthi", "GioBatDau", c => c.String(maxLength: 20));
        }
    }
}

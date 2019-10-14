using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Material: Page
    {
        //[Key]
        public int DirectoryId { get; set; } //Внешний ключ
        public Directory Directory { get; set; } //Навигационное свойство
    }
}

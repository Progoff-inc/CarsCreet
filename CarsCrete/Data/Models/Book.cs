﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCrete.Data.Models
{
    public class Book
    {
        #region Constructor
        public Book()
        {

        }
        #endregion
        #region Properties
        [Key]
        [Required]
        public long Id { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateFinish { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long CarId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Place { get; set; }
        #endregion
        #region Lazy-loading
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
        #endregion


    }
}

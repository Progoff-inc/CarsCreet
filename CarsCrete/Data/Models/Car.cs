﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsCrete.Data.Models
{
    public class Car
    {
        #region Constructor
        public Car()
        {

        }
        #endregion
        #region Properties
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public int Passengers { get; set; }

        [Required]
        public int Doors { get; set; }

        [Required]
        public string Transmission { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public int Consumption { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DefaultValue("Eng description of the car.")]
        public string Description_ENG { get; set; }

        [Required]
        public double Price { get; set; }
        [DefaultValue(0)]
        public ushort Mark { get; set; }
        #endregion
        #region Lazy-Load Properties
        /// <summary>
        /// A list containing all the reports related to this car.
        /// It will be populaed on first use thanks to the EF Lazy-Loading feature.
        /// </summary>
        public virtual List<FeedBack> Reports { get; set; }
        public virtual List<Book> Books { get; set; }
        #endregion
    }
}

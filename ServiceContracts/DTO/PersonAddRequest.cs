﻿using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        [Display(Name = "Person Name")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage ="Email cannot be null")]
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "Please write {0} in a proper format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please provide a {0}")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please provide a {0}")]
        [Display(Name = "Gender")]
        [EnumDataType(typeof(PersonGenderEnum), ErrorMessage = "Please select a {0}")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public PersonGenderEnum? Gender { get; set; }

        [Required(ErrorMessage = "Please provide a {0}")]
        [Display(Name = "CountryID")]
        [DataType(DataType.Text)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public Guid? CountryID { get; set; }

        [Required(ErrorMessage = "Please provide a {0}")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Address cannot be more than {1} characters")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Address{ get; set; }

        [Required(ErrorMessage ="Please provide a {0}")]
        [Display(Name = "Recieves News Letters")]
        public bool? RecievesNewsLetters { get; set; }


        public Person ToPerson()
        {
            return new Person()
            {
                PersonID = Guid.NewGuid(),
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                RecievesNewsLetters = RecievesNewsLetters

            };
        }

    }
}

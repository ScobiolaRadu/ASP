﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ProiectOpt.Models
{
    public class ComandaClient
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ComandaDetalii { get; set; }

        public Client Client { get; set; }
    }
}
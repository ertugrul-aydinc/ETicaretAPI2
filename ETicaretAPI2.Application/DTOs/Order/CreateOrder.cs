﻿using ETicaretAPI2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.Application.DTOs.Order
{
	public class CreateOrder
	{
		public string? BasketId { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
	}
}
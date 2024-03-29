﻿using ETicaretAPI2.Application.Consts;
using ETicaretAPI2.Application.CustomAttributes;
using ETicaretAPI2.Application.Enums;
using ETicaretAPI2.Application.Features.Commands.Order.CompleteOrder;
using ETicaretAPI2.Application.Features.Commands.Order.CreateOrder;
using ETicaretAPI2.Application.Features.Queries.Order.GetAllOrders;
using ETicaretAPI2.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI2.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes ="Admin")]
	public class OrdersController : ControllerBase
	{
		readonly IMediator _mediator;

		public OrdersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order By Id")]
        public async Task<IActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
		{
			GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
			return Ok(response);
		}

		[HttpGet]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Orders, ActionType = ActionType.Reading, Definition = "Get All Orders")]
        public async Task<IActionResult> GetAllOrders([FromQuery]GetAllOrdersQueryRequest getAllOrdersQueryRequest)
        {
            GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Orders, ActionType = ActionType.Writing, Definition = "Create Order")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
		{
			CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
			return Ok(response);
		}

		[HttpGet("complete-order/{Id}")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Orders, ActionType = ActionType.Updating, Definition = "Complete Order")]
        public async Task<IActionResult> CompleteOrder([FromRoute]CompleteOrderCommandRequest completeOrderCommandRequest)
		{
			CompleteOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
			return Ok(response);
		}
	}
}

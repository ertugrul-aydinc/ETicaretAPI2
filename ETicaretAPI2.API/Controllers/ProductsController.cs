﻿using ETicaretAPI2.Application.Abstractions.Services;
using ETicaretAPI2.Application.Abstractions.Storage;
using ETicaretAPI2.Application.Consts;
using ETicaretAPI2.Application.CustomAttributes;
using ETicaretAPI2.Application.Enums;
using ETicaretAPI2.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI2.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI2.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI2.Application.Features.Commands.Product.UpdateStockQrCodeToProduct;
using ETicaretAPI2.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using ETicaretAPI2.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ETicaretAPI2.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretAPI2.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI2.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI2.Application.Features.Queries.ProductImageFile.GetProductImages;
using ETicaretAPI2.Application.Repositories;
using ETicaretAPI2.Application.Repositories.ProductImageFile;
using ETicaretAPI2.Application.RequestParameters;
using ETicaretAPI2.Application.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETicaretAPI2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly IMediator _mediator;

        readonly IProductService _productService;

        public ProductsController(IMediator mediator, IProductService productService)
        {
            _mediator = mediator;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

            return Ok(response);
        }

        [HttpGet("qrcode/{productId}")]
        public async Task<IActionResult> GetQrCodeToProduct([FromRoute] string productId)
        {
            var data = await _productService.QrCodeToProductAsync(productId);

            return File(data, "image/png");
        }

        [HttpPut("qrcode")]
        public async Task<IActionResult> UpdateStockQrCodeToProduct(UpdateStockQrCodeToProductCommandRequest updateStockQrCodeToProductCommandRequest)
        {
            UpdateStockQrCodeToProductCommandResponse response = await _mediator.Send(updateStockQrCodeToProductCommandRequest);

            return Ok(response);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {

            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);

            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);

            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            uploadProductImageCommandRequest.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);

            return Ok();

        }

        [HttpGet("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Images")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Image")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);

            return Ok();
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefiniton(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Updating, Definition = "Change Showcase Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        { 
            ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok(response);
        }

    }
}

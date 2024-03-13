﻿using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Insfrastructure.Repository;
using LanVar.Service.Interface;
using LanVar.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace LanDotBien_BackEnd.Controllers.CustomerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAndBuyProduct : ControllerBase
    {
        private readonly IProductService _productService;

        public SearchAndBuyProduct(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("SearchProducts")]
        public async Task<IActionResult> SearchProductsAsync(SearchProductDTORequest searchRequest)
        {
            try
            {
                var results = await _productService.SearchProductsAsync(searchRequest);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("BuyProduct/{productId}")]
        public async Task<IActionResult> BuyProduct(int productId)
        {
            try
            {
                var result = await _productService.BuyProductAsync(productId);
                if (result)
                {
                    return Ok("Product purchased successfully.");
                }
                else
                {
                    return NotFound("Product not found or unable to purchase.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

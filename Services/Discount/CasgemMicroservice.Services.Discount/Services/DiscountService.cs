﻿using AutoMapper;
using CasgemMicroservice.Services.Discount.Context;
using CasgemMicroservice.Services.Discount.Dtos;
using CasgemMicroservice.Services.Discount.Models;
using CasgemMicroservice.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CasgemMicroservice.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        private readonly IMapper _mapper;

        public DiscountService(DapperContext dapperContext, IMapper mapper)
        {
            _dapperContext = dapperContext;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateDiscountCouponsAsync(CreateDiscountDto createDiscountDto)
        {
            var createCoupon = _mapper.Map<DiscountCoupons>(createDiscountDto);
            createCoupon.CreatedTime = DateTime.Now;

            await _dapperContext.DiscountCoupons.AddAsync(createCoupon);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(201);
        }

        public async Task<Response<NoContent>> DeleteDiscountCouponsAsync(int id)
        {
            var result = await _dapperContext.DiscountCoupons.FindAsync(id);
            if (result == null)
            {
                return Response<NoContent>.Fail("Silinecek Kupon Bulunamadı", 404);
            }
            _dapperContext.DiscountCoupons.Remove(result);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync()
        {
            var values = await _dapperContext.DiscountCoupons.ToListAsync();
            return Response<List<ResultDiscountDto>>.Success(_mapper.Map<List<ResultDiscountDto>>(values), 200);
        }

        public async Task<Response<ResultDiscountDto>> GetByIdDiscountCouponsAsync(int id)
        {
            var result = await _dapperContext.DiscountCoupons.FindAsync(id);
            return Response<ResultDiscountDto>.Success(_mapper.Map<ResultDiscountDto>(result), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCouponsAsync(UpdateDiscountDto updateDiscountDto)
        {
            var existingResponse = await _dapperContext.DiscountCoupons.FindAsync(updateDiscountDto.DiscountCouponsID);
            if (existingResponse != null)
            {
                return Response<NoContent>.Fail("Güncellenecek Kupon", 404);
            }
            _mapper.Map(updateDiscountDto, existingResponse);
            _dapperContext.DiscountCoupons.Update(existingResponse);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }
    }
}

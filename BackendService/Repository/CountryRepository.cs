﻿using System;
using AutoMapper;
using BackendService.Data;
using BackendService.Interfaces;
using BackendService.Models;

namespace BackendService.Repository
{
	public class CountryRepository:ICountryRepository
	{
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContext context, IMapper mapper)
		{
            _context = context;
            _mapper = mapper;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(p => p.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByVendor(int vendorId)
        {
            return _context.Vendors.Where(v => v.Id == vendorId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Vendor> GetVendorsFromCountry(int countryId)
        {
            return _context.Vendors.Where(c => c.Country.Id == countryId).OrderBy(v=>v.Id).ToList();
        }
    }
}

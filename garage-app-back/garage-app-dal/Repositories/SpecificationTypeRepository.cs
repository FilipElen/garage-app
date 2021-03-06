﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using garage_app_entities;

namespace DAL.Repositories
{
    public class SpecificationTypeRepository
    {
        private readonly MyDbContext _context;

        public SpecificationTypeRepository(MyDbContext context)
        {
            _context = context;
        }

        public void InsertSpecificationType(SpecificationType specificationType)
        {
            _context.SpecificationTypes.Add(specificationType);
            _context.SaveChanges();
        }

        public List<SpecificationType> GetSpecificationTypes()
        {
            return _context.SpecificationTypes.ToList();
        }

        public List<SpecificationType> GetRequiredCarSpecificationTypes()
        {
            return _context.SpecificationTypes.Where(specificationType => specificationType.IsRequiredForCar)
                .ToList();
        }
        public SpecificationType FindSpecificationType(int id)
        {
            return _context.SpecificationTypes.Find(id);
        }

        public SpecificationType FindSpecificationType(string type)
        {
            return _context.SpecificationTypes.FirstOrDefault(c => c.Type.Equals(type));
        }

        public void UpdateSpecificationType(SpecificationType specificationType)
        {
            _context.SpecificationTypes.Attach(specificationType);
            _context.Entry(specificationType).State = EntityState.Modified;

            foreach (Specification specification in specificationType.Specifications)
            {
                _context.Specifications.Attach(specification);
            }

            _context.SaveChanges();
        }

        public void DeleteSpecificationType(int id)
        {
            SpecificationType specificationTypeFromDb = _context.SpecificationTypes.Find(id);
            if (specificationTypeFromDb != null)
            {
                _context.SpecificationTypes.Remove(specificationTypeFromDb);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("specificationType was not found!");
            }
        }
    }
}
﻿using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        public readonly List<IDiver> models;

        public DiverRepository()
        {
            models = new List<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models => models.AsReadOnly();

        public void AddModel(IDiver model) => models.Add(model);

        public IDiver GetModel(string name) => models.FirstOrDefault(x => x.Name == name);
    }
}

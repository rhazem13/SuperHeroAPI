using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext context;

        public SuperHeroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero newHero)
        {
            context.SuperHeroes.Add(newHero);
            await context.SaveChangesAsync();
            return context.SuperHeroes.ToList();
        }

        public async Task<List<SuperHero>>? DeleteHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();
            return context.SuperHeroes.ToList();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes= await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero>? GetSingleHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>>? UpdateHero(int id, SuperHero newHero)
        {
            var hero =await  context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            hero.Name = newHero.Name;
            hero.FirstName = newHero.FirstName;
            hero.LastName = newHero.LastName;
            hero.Place = newHero.Place;

            context.SaveChanges();
            return context.SuperHeroes.ToList();
        }
    }
}

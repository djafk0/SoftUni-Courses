using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void ConstructorShouldWorksCorrectly()
    {
        HeroRepository repository = new HeroRepository();

        Assert.IsNotNull(repository);
    }

    [Test]
    public void CreateMethodShouldThrowsAnExceptionWhenHeroIsNull()
    {
        HeroRepository repository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => repository.Create(null));
    }

    [Test]
    public void CreateMethodShouldThrowsAnExceptionWhenHeroExist()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho", 3);
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() => repository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldWorksCorrectly()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Pesho", 3);
        repository.Create(hero);

        List<Hero> list = new List<Hero>();
        list.Add(hero);

        Assert.AreEqual(1, list.Count);
    }

    [Test]
    public void RemoveMethodShouldThrowsAnExceptionWhenNameIsNull()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(""));
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(" "));
    }

    [Test]
    public void RemoveMethodShouldWorksCorrectly()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("pesho", 3));

        bool isRemoved = heroRepository.Remove("pesho");

        Assert.IsTrue(isRemoved);
    }

    [Test]
    public void RemoveMethodShouldWorksCorrectlyWithInvalidData()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("pesho", 3));

        bool isRemoved = heroRepository.Remove("peshoooooo");

        Assert.IsFalse(isRemoved);
    }

    [Test]
    public void GetHeroWithHighestLevel()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("pesho", 3));
        heroRepository.Create(new Hero("peshkata", 6));
        heroRepository.Create(new Hero("pushkulka", 4));

        Assert.AreEqual("peshkata", heroRepository.GetHeroWithHighestLevel().Name);
    }

    [Test]
    public void GetHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(new Hero("pesho", 3));
        heroRepository.Create(new Hero("peshkata", 6));
        heroRepository.Create(new Hero("pushkulka", 4));

        Assert.AreEqual("pushkulka", heroRepository.GetHero("pushkulka").Name);
    }
    //public Hero GetHeroWithHighestLevel()
    //{
    //    Hero hero = this.data.OrderByDescending(h => h.Level).ToArray()[0];
    //    return hero;
    //}

    //public Hero GetHero(string name)
    //{
    //    Hero hero = this.data.FirstOrDefault(h => h.Name == name);
    //    return hero;
    //}
}
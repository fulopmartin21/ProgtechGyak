using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Progtech_Beadando.Tests
{
    [TestClass]
    class BuilderTests
    {
        [TestMethod]
        public void BuilderTest1()
        {
            // Inicializálás
            List<Extras> list = new List<Extras>();
            SUVCarBuilder builder = new SUVCarBuilder();
            Director director = new Director(builder);

            // Folyamat futtatás
            director.createSUVCar(list);
            Car car = builder.getCar();
            car.brand = "Suzuki";
            car.type = "SUV";

            // Tesztelés
            Assert.AreEqual(24320000,car.price,0.001,"Nem egyező árak!");
            Assert.IsTrue(car.charger, "Nincs egyezés a sportváltóról!");
            Assert.IsFalse(car.computer, "Nincs egyezés a fedélzeti computer meglétéről!");
            Assert.AreEqual(400, car.engine, "Nincs egyezés a motor lóerejét!");
            Assert.AreEqual(4, car.tires, "Nincs egyezés a kerekeket illetően!");
            BuilderTest2();
        }
        [TestMethod]
        public void BuilderTest2()
        {
            // Inicializálás
            List<Extras> list = new List<Extras>();
            Extras extra = new Extras();
            extra.name = "Klíma";
            extra.price = 200000;
            list.Add(extra);
            SedanCarBuilder builder = new SedanCarBuilder();
            Director director = new Director(builder);

            // Folyamat futtatás
            director.createSedanCar(list);
            Car car = builder.getCar();
            car.brand = "Audi";
            car.type = "Sedan";

            // Tesztelés
            Assert.AreEqual(2490000, car.price, 0.001, "Nem egyező árak!");
            Assert.IsFalse(car.charger, "Nincs egyezés a sportváltóról!");
            Assert.IsFalse(car.computer, "Nincs egyezés a fedélzeti computer meglétéről!");
            Assert.AreEqual(150, car.engine, "Nincs egyezés a motor lóerejét!");
            Assert.AreEqual(4, car.tires, "Nincs egyezés a kerekeket illetően!");
            BuilderTest3();
        }
        [TestMethod]
        public void BuilderTest3()
        {
            // Inicializálás
            List<Extras> list = new List<Extras>();
            Extras extra = new Extras();
            extra.name = "Vadriasztó";
            extra.price = 50000;
            list.Add(extra);
            HibridCarBuilder builder = new HibridCarBuilder();
            Director director = new Director(builder);

            // Folyamat futtatás
            director.createHibridCar(list);
            Car car = builder.getCar();
            car.brand = "Mercedes";
            car.type = "Hibrid";

            // Tesztelés
            Assert.AreEqual(4210000, car.price, 0.001, "Nem egyező árak!");
            Assert.IsTrue(car.charger, "Nincs egyezés a sportváltóról!");
            Assert.IsFalse(car.computer, "Nincs egyezés a fedélzeti computer meglétéről!");
            Assert.AreEqual(200, car.engine, "Nincs egyezés a motor lóerejét!");
            Assert.AreEqual(4, car.tires, "Nincs egyezés a kerekeket illetően!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Storage;

namespace TestLogic
{
    /// <summary>
    /// Classe testant les fonctions de JsonStorage
    /// </summary>
    public class TestJsonStorage
    {
        /// <summary>
        /// Fonction testant la sauvegarde et le chargement d'une sauvegarde;
        /// </summary>
        [Fact]
        public void TestSaveAndLoad()
        {
            //on créé un notebook
            Notebook expected = new Notebook();

            //on créé 4 unit
            Unit u1 = new Unit();
            u1.Name = "1";
            Unit u2 = new Unit();
            u2.Name = "2";
            Unit u3 = new Unit();
            u3.Name = "3";
            Unit u4 = new Unit();
            u4.Name = "4";

            //on créé 8 modules (2 par units);
            Module u1m1 = new Module();
            Module u1m2 = new Module();
            Module u2m1 = new Module();
            Module u2m2 = new Module();
            Module u3m1 = new Module();
            Module u3m2 = new Module();
            Module u4m1 = new Module();
            Module u4m2 = new Module();

            //on ajoute les modules aux units
            u1.AddModules(u1m1);
            u1.AddModules(u1m2);
            u2.AddModules(u2m1);
            u2.AddModules(u2m2);
            u3.AddModules(u3m1);
            u3.AddModules(u3m2);
            u4.AddModules(u4m1);
            u4.AddModules(u4m2);

            //on ajoute les units au notebook
            expected.AddUnit(u1);
            expected.AddUnit(u2);
            expected.AddUnit(u3);
            expected.AddUnit(u4);

            //on créé un JsonStorage
            JsonStorage js = new JsonStorage("data.json");

            js.Save(expected);

            Notebook actual = js.Load();

            Assert.True(expected.Equals(actual));
        }
    }
}

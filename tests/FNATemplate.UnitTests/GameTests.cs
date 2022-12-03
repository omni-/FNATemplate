using FNATemplate.Constants;
using FNATemplate.Input;

namespace FNATemplate.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void KeyMapHasValues()
        {
            PlayerInput p = new();
            Assert.IsTrue(p.KeyMap.ContainsValue(Actions.MoveUp));
        }
    }
}
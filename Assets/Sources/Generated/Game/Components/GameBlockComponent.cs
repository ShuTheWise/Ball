//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BlockComponent blockComponent = new BlockComponent();

    public bool isBlock {
        get { return HasComponent(GameComponentsLookup.Block); }
        set {
            if (value != isBlock) {
                if (value) {
                    AddComponent(GameComponentsLookup.Block, blockComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Block);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBlock;

    public static Entitas.IMatcher<GameEntity> Block {
        get {
            if (_matcherBlock == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Block);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBlock = matcher;
            }

            return _matcherBlock;
        }
    }
}

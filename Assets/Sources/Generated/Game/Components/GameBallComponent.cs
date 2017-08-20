//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly BallComponent ballComponent = new BallComponent();

    public bool isBall {
        get { return HasComponent(GameComponentsLookup.Ball); }
        set {
            if (value != isBall) {
                if (value) {
                    AddComponent(GameComponentsLookup.Ball, ballComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Ball);
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

    static Entitas.IMatcher<GameEntity> _matcherBall;

    public static Entitas.IMatcher<GameEntity> Ball {
        get {
            if (_matcherBall == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Ball);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBall = matcher;
            }

            return _matcherBall;
        }
    }
}
using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

public class CharacteristicTypeSymbol : SourceCatalogueItemSymbol, ICharacteristicTypeSymbol
{
    internal new CharacteristicTypeNode Declaration { get; }

    public CharacteristicTypeSymbol(
        IProfileTypeSymbol containingSymbol,
        CharacteristicTypeNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration)
    {
        Declaration = declaration;
        ContainingProfileType = containingSymbol;
    }

    public override SymbolKind Kind => SymbolKind.ResourceType;

    public IProfileTypeSymbol ContainingProfileType { get; }
}

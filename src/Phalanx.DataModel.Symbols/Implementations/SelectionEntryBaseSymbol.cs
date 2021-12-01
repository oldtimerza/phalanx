using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation;

public abstract class SelectionEntryBaseSymbol : ContainerEntryBaseSymbol, ISelectionEntryContainerSymbol
{
    protected SelectionEntryBaseSymbol(
        ICatalogueItemSymbol containingSymbol,
        SelectionEntryBaseNode declaration,
        DiagnosticBag diagnostics)
        : base(containingSymbol, declaration, diagnostics)
    {
        Categories = CreateCategoryEntries().ToImmutableArray();
        PrimaryCategory = Categories.FirstOrDefault(x => x.IsPrimaryCategory);
        ChildSelectionEntries = CreateSelectionEntryContainers().ToImmutableArray();

        IEnumerable<ICategoryEntrySymbol> CreateCategoryEntries()
        {
            foreach (var item in declaration.CategoryLinks)
            {
                yield return CreateEntry(this, item, diagnostics);
            }
        }
        IEnumerable<ISelectionEntryContainerSymbol> CreateSelectionEntryContainers()
        {
            foreach (var item in declaration.EntryLinks)
            {
                yield return CreateEntry(this, item, diagnostics);
            }
            foreach (var item in declaration.SelectionEntries)
            {
                yield return CreateEntry(this, item, diagnostics);
            }
            foreach (var item in declaration.SelectionEntryGroups)
            {
                yield return CreateEntry(this, item, diagnostics);
            }
        }
    }

    public virtual ISelectionEntryContainerSymbol? ReferencedEntry => null;

    public ICategoryEntrySymbol? PrimaryCategory { get; }

    public ImmutableArray<ICategoryEntrySymbol> Categories { get; }

    public ImmutableArray<ISelectionEntryContainerSymbol> ChildSelectionEntries { get; }

    public virtual bool IsSelectionEntry => false;

    public virtual bool IsSelectionGroup => false;

    protected sealed override IEntrySymbol? BaseReferencedEntry => ReferencedEntry;
}

using Phalanx.DataModel.Symbols.Binding;
using WarHub.ArmouryModel.Source;

namespace Phalanx.DataModel.Symbols.Implementation
{
    public class QuerySymbol : LogicSymbol, IQuerySymbol
    {
        public QuerySymbol(
            ICatalogueItemSymbol containingSymbol,
            QueryBaseNode query,
            BindingDiagnosticContext diagnostics)
            : base(containingSymbol)
        {
            // TODO query
        }
    }
}

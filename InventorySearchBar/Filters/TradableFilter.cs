using Lumina.Excel.Sheets;

namespace InventorySearchBar.Filters;

internal class TradableFilter : Filter
{
    public override string Name => "Tradable";
    public override string HelpText => "Allow to filter items by checking if they're tradable.\nExamples: '" + Plugin.Settings.TradableFilterTag + ":true', '" + Plugin.Settings.TradableFilterTag + ":y', '" + Plugin.Settings.TradableFilterAbbreviatedTag + ":1'.";

    protected override bool Enabled
    {
        get => Plugin.Settings.TradableFilterEnabled;
        set => Plugin.Settings.TradableFilterEnabled = value;
    }

    protected override bool NeedsTag
    {
        get => Plugin.Settings.TradableFilterRequireTag;
        set => Plugin.Settings.TradableFilterRequireTag = value;
    }

    protected override string Tag
    {
        get => Plugin.Settings.TradableFilterTag;
        set => Plugin.Settings.TradableFilterTag = value;
    }

    protected override string AbbreviatedTag
    {
        get => Plugin.Settings.TradableFilterAbbreviatedTag;
        set => Plugin.Settings.TradableFilterAbbreviatedTag = value;
    }

    protected override bool Execute(Item item, string term)
    {
        term = term.ToLower();
        var wanted = term is "y" or "1" or "true" or "yes";
        return !item.IsUntradable == wanted;
    }
}
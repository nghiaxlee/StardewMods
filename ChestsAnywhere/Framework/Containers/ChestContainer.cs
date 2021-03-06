using System.Collections.Generic;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;

namespace Pathoschild.Stardew.ChestsAnywhere.Framework.Containers
{
    /// <summary>A storage container for an in-game chest.</summary>
    internal class ChestContainer : IContainer
    {
        /*********
        ** Properties
        *********/
        /// <summary>The in-game chest.</summary>
        private readonly Chest Chest;


        /*********
        ** Accessors
        *********/
        /// <summary>The underlying inventory.</summary>
        public List<Item> Inventory => this.Chest.items;

        /// <summary>The container's name.</summary>
        public string Name
        {
            get => this.Chest.Name;
            set => this.Chest.name = value;
        }

        /// <summary>Whether the player can configure the container.</summary>
        public bool IsEditable { get; }

        /// <summary>Whether to enable chest-specific UI.</summary>
        public bool IsChest { get; }

        /// <summary>The container's original name.</summary>
        public string DefaultName => "Chest";

        /// <summary>The callback to invoke when an item is selected in the player inventory.</summary>
        public ItemGrabMenu.behaviorOnItemSelect GrabItemFromInventory => this.Chest.grabItemFromInventory;

        /// <summary>The callback to invoke when an item is selected in the storage container.</summary>
        public ItemGrabMenu.behaviorOnItemSelect GrabItemFromContainer => this.Chest.grabItemFromChest;


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="chest">The in-game chest.</param>
        /// <param name="isEditable">Whether the player can configure the container.</param>
        /// <param name="isChest">Whether to enable chest-specific UI.</param>
        public ChestContainer(Chest chest, bool isEditable = true, bool isChest = true)
        {
            this.Chest = chest;
            this.IsEditable = isEditable;
            this.IsChest = isChest;
        }

        /// <summary>Get whether the in-game container is open.</summary>
        public bool IsOpen()
        {
            return this.Chest.currentLidFrame == 135;
        }

        /// <summary>Get whether the container has its default name.</summary>
        public bool HasDefaultName()
        {
            return this.Name == this.DefaultName;
        }

        /// <summary>Get whether the inventory can accept the item type.</summary>
        /// <param name="item">The item.</param>
        public bool CanAcceptItem(Item item)
        {
            return InventoryMenu.highlightAllItems(item);
        }
    }
}

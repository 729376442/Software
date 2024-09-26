using System;
using System.IO;
using System.Reflection;
using EFT;
using EFT.InventoryLogic;
using System.Collections.Generic;
using Comfort.Common;
using EFT.Interactive;
using UnityEngine;
using System.Linq;
using EFT.Hideout;
using EFT.UI.DragAndDrop;
using System.Collections;

public class ItemFactory
{
    private static string _logFilePath;
    private static Type _itemFactoryType;
    private static MethodInfo _createItemMethod;
    private static object _singletonInstance;

    static ItemFactory()
    {
        LoadItemFactoryType();
    }

    private static void LoadItemFactoryType()
    {
        Assembly assembly = Assembly.Load("Assembly-CSharp");
        if (assembly == null)
        {
            Log("Log: Failed to load Assembly-CSharp.");
            return;
        }
        Log("Log: Assembly-CSharp loaded successfully.");

        foreach (Type type in assembly.GetTypes())
        {
            _createItemMethod = type.GetMethod("CreateItem", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (_createItemMethod != null)
            {
                _itemFactoryType = type;
                break;
            }
        }

        if (_itemFactoryType == null)
        {
            Log("Log: Failed to find ItemFactory type.");
            return;
        }

        Log($"Log: Found ItemFactory type: {_itemFactoryType.FullName}");

        Type singletonGenericType = typeof(Singleton<>).MakeGenericType(_itemFactoryType);
        PropertyInfo instanceProperty = singletonGenericType.GetProperty("Instance", BindingFlags.Static | BindingFlags.Public);
        if (instanceProperty != null)
        {
            _singletonInstance = instanceProperty.GetValue(null);
        }
    }

    public Item CreateItem(string id)
    {
        if (_createItemMethod == null || _singletonInstance == null)
        {
            Log("Log: ItemFactory is not properly initialized.");
            return null;
        }

        Log($"Log: Creating item with ID: {id}");

        string mongoID = MongoID.Generate();
        object[] parameters = new object[] { mongoID, id, null };
        object oItem = _createItemMethod.Invoke(_singletonInstance, parameters);

        if (oItem != null)
        {
            Log("Log: Item creation successful.");
            Item result = (Item)oItem;
            result.StackObjectsCount = result.StackMaxSize;
            result.SpawnedInSession = true;
            return (Item)oItem;
        }
        else
        {
            Log("Log: Item creation failed.");
            return null;
        }
    }

    public CompoundItem CreateCompoundItem(string id)
    {
        if (_createItemMethod == null || _singletonInstance == null)
        {
            Log("Log: ItemFactory is not properly initialized.");
            return null;
        }

        Log($"Log: Creating item with ID: {id}");

        string mongoID = MongoID.Generate();
        object[] parameters = new object[] { mongoID, id, null };
        object oItem = _createItemMethod.Invoke(_singletonInstance, parameters);

        if (oItem != null)
        {
            Log("Log: Item creation successful.");
            CompoundItem result = (CompoundItem)oItem;
            result.SpawnedInSession = true;
            return result;
        }
        else
        {
            Log("Log: Item creation failed.");
            return null;
        }
    }
    public static void Log(string message)
    {
        _logFilePath = Path.Combine(Application.persistentDataPath, "log.txt");
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
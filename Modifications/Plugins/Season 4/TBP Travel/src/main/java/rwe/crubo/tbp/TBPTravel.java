package rwe.crubo.tbp;

import org.bukkit.plugin.java.JavaPlugin;

public class TBPTravel extends JavaPlugin {

    private static TBPTravel instance;

    @Override
    public void onEnable() {
        instance = this;
        saveDefaultConfig();
        getCommand("carttravel").setExecutor(new TravelCommand());
        getCommand("cartarrival").setExecutor(new TravelCommand());
    }

    public static TBPTravel getInstance() {
        return instance;
    }
}

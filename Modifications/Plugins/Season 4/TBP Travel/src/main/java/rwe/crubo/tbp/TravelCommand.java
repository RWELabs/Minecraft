package rwe.crubo.tbp;

import org.bukkit.Bukkit;
import org.bukkit.ChatColor;
import org.bukkit.Location;
import org.bukkit.Material;
import org.bukkit.command.Command;
import org.bukkit.command.CommandExecutor;
import org.bukkit.command.CommandSender;
import org.bukkit.configuration.ConfigurationSection;
import org.bukkit.plugin.Plugin;
import org.bukkit.scheduler.BukkitRunnable;

public class TravelCommand implements CommandExecutor {

    private Plugin plugin = TBPTravel.getInstance();

    @Override
    public boolean onCommand(CommandSender sender, Command command, String label, String[] args) {
        if (command.getName().equalsIgnoreCase("carttravel")) {
            return handleDeparture(sender, args);
        } else if (command.getName().equalsIgnoreCase("cartarrival")) {
            return handleArrival(sender, args);
        }
        return false;
    }

    private boolean handleDeparture(CommandSender sender, String[] args) {
        if (args.length != 2) {
            sender.sendMessage(ChatColor.RED + "Usage: /carttravel <from> <to>");
            return false;
        }

        String from = args[0];
        String to = args[1];

        ConfigurationSection stations = plugin.getConfig().getConfigurationSection("Stations");
        if (stations == null || !stations.contains(from) || !stations.contains(to)) {
            sender.sendMessage(ChatColor.RED + "Unknown station(s). Check config.");
            return false;
        }

        String fromName = plugin.getConfig().getString("Stations." + from + ".Name");
        String toName = plugin.getConfig().getString("Stations." + to + ".Name");

        Bukkit.broadcastMessage(ChatColor.GOLD + "Travel has commenced from " +
                ChatColor.YELLOW + fromName +
                ChatColor.GOLD + ", travelling to " +
                ChatColor.YELLOW + toName + ChatColor.GOLD + ".");

        lightLantern(from);
        lightLantern(to);

        return true;
    }

    private boolean handleArrival(CommandSender sender, String[] args) {
        if (args.length != 2) {
            sender.sendMessage(ChatColor.RED + "Usage: /cartarrival <from> <to>");
            return false;
        }

        String from = args[0];
        String to = args[1];

        ConfigurationSection stations = plugin.getConfig().getConfigurationSection("Stations");
        if (stations == null || !stations.contains(from) || !stations.contains(to)) {
            sender.sendMessage(ChatColor.RED + "Unknown station(s). Check config.");
            return false;
        }

        String fromName = plugin.getConfig().getString("Stations." + from + ".Name");
        String toName = plugin.getConfig().getString("Stations." + to + ".Name");

        Bukkit.broadcastMessage(ChatColor.GREEN + "Travel has been completed from " +
                ChatColor.YELLOW + fromName +
                ChatColor.GREEN + " to " +
                ChatColor.YELLOW + toName + ChatColor.GREEN + ". Line is now available.");

        extinguishLantern(from);
        extinguishLantern(to);

        return true;
    }

    private void lightLantern(String stationKey) {
        String[] coords = plugin.getConfig().getString("Stations." + stationKey + ".Lantern").split(",");
        if (coords.length != 3) return;

        int x = Integer.parseInt(coords[0]);
        int y = Integer.parseInt(coords[1]);
        int z = Integer.parseInt(coords[2]);

        Location loc = new Location(Bukkit.getWorlds().get(0), x, y, z);
        loc.getBlock().setType(Material.REDSTONE_LAMP);

        Location powerLoc = loc.clone().add(0, 1, 0);
        powerLoc.getBlock().setType(Material.REDSTONE_BLOCK);

        new BukkitRunnable() {
            @Override
            public void run() {
                powerLoc.getBlock().setType(Material.AIR);
            }
        }.runTaskLater(plugin, 200L); // 10 seconds
    }

    private void extinguishLantern(String stationKey) {
        String[] coords = plugin.getConfig().getString("Stations." + stationKey + ".Lantern").split(",");
        if (coords.length != 3) return;

        int x = Integer.parseInt(coords[0]);
        int y = Integer.parseInt(coords[1]);
        int z = Integer.parseInt(coords[2]);

        Location loc = new Location(Bukkit.getWorlds().get(0), x, y, z);
        Location powerLoc = loc.clone().add(0, 1, 0);
        
        // Remove power source and reset lamp
        powerLoc.getBlock().setType(Material.AIR);
        loc.getBlock().setType(Material.REDSTONE_LAMP);
    }
}

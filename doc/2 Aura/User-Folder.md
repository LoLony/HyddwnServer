Aura uses 2 folders to organize databases, configurations, scripts, etc: "system" and "user". The developers only make changes in system, leaving the user folder to the user.

When loading data, the user folder is treated with a higher priority, making it possible for you to extend and modify things without touching the system files. This ensures that there will never be any conflicts when updating, you could copy a new version of Aura over the old one, overwriting everything, without losing your modifications.

While it's technically possible for you to just make your changes in the system folder, it's strongly recommended you only use user. Not only is it safer during updates, it also makes backups and similar operations much simpler. For example, if you wanted to start clean, all you have to do is download a new copy of Aura, copy your user folder to the new Aura folder, and you're done. All your settings and customizations are there.

- [Configuration](#configuration)
- [Databases](#databases)
- [Scripts](#scripts)

##Configuration

Conf files are loaded from the system folder first, from `system/conf/`. In each file you can see something like

```
include "/user/conf/channel.conf"
```
  
at the bottom. This instructs the server to include that file, if it exists. Values found in there will overwrite the things in the system's file.

For example, to change the password for your database, you would take a look at `system/conf/database.conf`, copy the line `pass : `, paste it into a new file at `user/conf/database.conf`, and change it to `pass : yourpassword`. The server would read the system's file, jump over to your file at the end, and overwrite the "pass" option with your setting.

##Databases

Databases in "db" are a little more special than configuration files, but the normal use cases, like adding or modifying items and races are straight forward enough.

Like with conf files, the server reads the files in system first and jumps over to user afterwards. This is done internally, without an explicit include. Again, the values are replaced, or added, from user. At least in the case of items and races.

For example, let's say we wanted to change the price of the Full Ring Mail to 1,000 Gold. In `system/db/items.txt` you will find this line:

```
{ id: 13000, name: "Full Ring Mail", originalName: "Full Ring Mail", [...], type: 0, width: 2, height: 4, price: 347000, [...]
```

Now you would make a new file in user, `user/db/items.txt`, copy over the
line, change the value:

```
{ id: 13000, name: "Full Ring Mail", originalName: "Full Ring Mail", [...], type: 0, width: 2, height: 4, price: 1000, [...]
```

and you'd be done. The server would read the system file, jump over at the end and replace the system's Full Ring Mail with the one from your user folder.

This works for most dbs, but not all of them. For example, character card sets (charcardsets.txt) can't be replaced, only added. This is because the lines aren't indexed by anything, like an item or race id, every line is an item that is added. There's currently no way to change this, but it shouldn't matter in most cases.

##Scripts

The last type, and the most "complicated" one, are the scripts.

Our journey starts at `system/scripts/scripts.txt`, a list of files that are to be loaded. Right at the top, after the header, you see

```
divert "/user/scripts/scripts.txt"
```

This line works similar to an include, but if the include is successful, meaning the other file was found, the server won't come back to the system file. If you add that file to your user folder, you'll basically replace the whole loading strategy. This will be rarely necessary, it exists just in case you need a way to basically control everything yourself.

After that, you see multiple includes for various lists. These work as expected, the other lists are read, one after the other. For example,

```
include "scripts_npcs.txt"
```

will read "scripts_npcs.txt" and load all files listed in there, like

```
npcs/tir/duncan.cs
```

While includes use a relative path, script files are loaded from the user folder first. This means that if you see an include in a system list, it includes that file from the system folder. But if the server encounters the Duncan line above, it will look for the file at `user/scripts/npcs/tir/duncan.cs` first. If it can't be found there, the server takes the file in system instead.

This way it is easy to replace a script completely, by creating a file with the same name, in the same spot, but in the user folder. This has to be kept in mind when creating new files though, because you could accidentally name a script the same way and put in the same spot in the folder structure.

The best strategy when creating custom scripts is putting them in a folder named "custom" and adding a list file at `user/scripts/scripts_custom.txt`. This file is set to be read in the system lists.

For example, you've created an NPC and you want to load it. You should put the script file into `user/scripts/custom/`. Afterwards you would add the list file `user/scripts/scripts_custom.txt` and add a single line to it:

```
custom/cool_npc.cs
```

The server would load the system list, encounter the include for the user's custom list, find the above line, and load your script.
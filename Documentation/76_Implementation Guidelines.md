Guidelines for plugin implementations {#guidelines}
===================================================

When implementing a plugin, please remember the following guidelines:

- <b>Speed</b><br/>The B2S.Server acts as a proxy between Visual Pinball in Pinmame. If the transfer of the data between the two is slowed down, the whole virtual pinball system will be slow down, which leads to unwanted behaviour like stuttering.<br/>Therefore it is important to make your plugin as fast as possible. If you have any longer running action in your plugin, execute them in a separate thread. 
- <b>Error handling</b><br/>It is important that all exceptions that might occur in your code are handled inside the plugin. If you pluging throws any unhandled exceptions, the B2S.Server will deactivate the plugin. You can check the status of the plugins in the plugin window of the B2S.Server.
- <b>B2SServerPluginInterface</b><br/>Dont compile your own B2SServerPluginInterface.dll. Download a binary version of the dll (e.g. together with the B2S.Server), to avaoid versioning problems.
- <b>Windows and Forms</b><br/>If your plugin opens and updates windows, it will likely slow down the system. Updating windows from separate threads is quite tricky and sometimes unreliable. In such a case you might want to consider running a separate process/exe file doing all work necessary to open and update windows (B2S.Server does the same thing).
- <b>Name</b><br/>Make sure you plugin returns something meaningful for the name property of the IDirectPlugin interface. It is recommended that you also include the version and/or the build date of you plugin in the Name property.

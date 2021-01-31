# Testing filesystem dynamics with Docker

This project has been a playground in which I explore how I can share a local folder with an app running in Docker.

Long story short; use `Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "yourAppName")` as place to dump dynamic files. This way;

1. Your files on Windows will reside in `C:/ProgramData/yourAppName`
2. Your files on a Linux Docker instance will reside in `/usr/share/yourAppName`

For more details, [check out my blogpost describing the intrinsics and mount behaviour here](https://corstianboerman.com/2021-01-31/accessing-the-file-system-with-asp-net-core-and-docker.html).

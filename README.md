# OnlineATV
This repository has all the stuff related to OnlineATV


## How the server works

The server is 3 things.
1. An RTMP server (ex. MediaMTX)
2. A hosting (I use playit.gg, but you can also port forward)
3. An FTP/HTTP server to put the IP on. (ex. ProFreeHost)

And with those 3 things, you'll be able to host and customize your own version of OnlineATV.

## The client

I made the client so you can easily watch OnlineATV streams (channels).
See [/OnlineATV Client/README.md](https://github.com/MarkPCExpertYT/OnlineATV/blob/master/OnlineATV%20Client/README.md) for info about the client

## How to stream to OnlineATV

To stream to OnlineATV, you'll need to change your server and stream key (in OBS).
Set the service to "Custom", and the server to `rtmp://rtmp://operating-webcast.gl.at.ply.gg:56742` and the stream key to `ch<1-10>` and replace `<1-10>` to a number between 1 and 10.
For example, `ch4` would be channel 4.

Since bandwidth is limited, I recommend streaming at 720x576@50 for 4:3 and 1024x576@50 for 16:9.

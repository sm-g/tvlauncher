@Echo off
"L:\Program Files\rtmpdump-2.3\rtmpdump" --rtmp "rtmp://fms.hutor.ru" --app "tv/" --swfUrl "http://tv.hutor.ru/player-licensed.swf" --tcUrl "rtmp://fms.hutor.ru/tv/" --playpath "1kanal_h.stream" --quiet | "L:\Program Files\vlc-2.0.3\vlc.exe" --sout="#std{access=http,mux=asf,dst=192.168.0.1:8001}" -
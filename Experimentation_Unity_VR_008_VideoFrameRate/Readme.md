The goal was to make a re-usable benchmark tool to analyse the quality of video playback.

To guaranty that we have proper graphic quality I have elaborated the following criteria: 99.9% of frames need to be rendered on time (which means faster than 10ms to cover the 90 HZ of Oculus HMD).

By using that benchmark tool, I was able to obtain objective data to compare the effect of different Unity technics and parameters (size of video, quality of import, comparison between a high-end computer and a basic VR Ready computer,…)

My strategy was:

1- for the purpose of the test I was deactivating the V-Sync so the app is refreshing as fast as possible.

2- at each frame I'm capturing the time elapsed since last frame

3- I use that number of milliseconds as the entry to increment the count (for this qty of ms per frame) in a map

4- I then walk the map and cumulate the counts to evaluate where are the 0.1%, the 0.1%, the 1% and the 10% limits.

5- I then display the information of the GUI.

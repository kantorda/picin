# picin

Picture Indexing Project

To Build:
- Pull Repo
- Download OpenCV
- Create environment variable "OPENCV_DIR" and point to "[OpenCV_Install_Location]\build\x64\vc15"
     - The projects use this EV to reference this location.  To continue without EV, open properties in each project in the solution and          replace all instances of "OPENCV_DIR" with the local path to the above.  Look in C++ and Linker Properties.
- Build All

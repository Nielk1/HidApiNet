HidApiNet
=========

[hidapi](https://github.com/signal11/hidapi) wrapper for .NET (works with mono on Raspberry) to talk to usb hid devices

### Installation

hidapi instalation instructions can be found in README.md in [hidapi](https://github.com/signal11/hidapi) repository.

For linux on Raspberry Pi it will be:
```sh
sudo apt-get install libudev-dev libusb-1.0-0-dev libfox-1.6-dev
sudo apt-get install autotools-dev autoconf automake libtool
git clone https://github.com/signal11/hidapi.git
cd hidapi
./bootstrap
./configure
make
make install --prefix=/usr/lib/arm-linux-gnueabihf  <----- as root, or using sudo
```

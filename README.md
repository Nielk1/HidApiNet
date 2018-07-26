HidApiNet
=========

[hidapi](https://github.com/signal11/hidapi) wrapper for .NET (works with mono on Raspberry) to talk to usb hid devices

HID documentation can be found [here](https://docs.mbed.com/docs/ble-hid/en/latest/api/md_doc_HID.html) (keyboard/mouse codes) or [here](https://github.com/czesiu/HidApiNet/blob/master/docs/Hut1_12v2.pdf) (more detailed documentation - keyboard codes at page 53).

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

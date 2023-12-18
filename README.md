# moovifier

![Project Card | moovifier](https://project-cards.jtpotatodev.workers.dev/?project=moovifier&started=17%20Dec%202023&codename=Lake%20Eyre)

moovifier is a Unity application to add motion to videos in real-time.

> [!WARNING]
> moovifier is _not_ built to be easily used by the wider community. Use of this thing is at your own expense. You will notice that there are no installation guides. Documentation is barely maintained. If you decide to fork this for whatever reason, let me use it 🙏

## Keybindings
| Key          | Description                                                                      |
| ------------ | -------------------------------------------------------------------------------- |
| `O`          | Opens the video path entry input box                                             |
| `Left Click` | Zooms into selected spot. If already zoomed in, re-centres to selected location. |
| `Escape`     | Zooms out                                                                        |

# Documentation
*Wait, there's documentation?*
Not really.

Code here is a mess - there's some combination of checking state every frame, and callback functions to orchestrate actions between different components.

Most state is centralised into `AppState` and `CameraState`. As far as I'm aware only `MovementHelper` uses callback functions.

Hopefully the file names point you in the right direction if you choose to change something.

The project uses URP.
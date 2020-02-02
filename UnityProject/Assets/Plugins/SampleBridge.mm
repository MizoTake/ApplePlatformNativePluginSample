#include <UnityProject-Swift.h>

extern "C" {
    const char* CallNativeString() {
        Sample *sample = [[Sample alloc] init];
        NSString *str = [sample Call];
        return strdup([str UTF8String]);
    }
}

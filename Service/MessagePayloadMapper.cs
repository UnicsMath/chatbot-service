using Model;
using Riok.Mapperly.Abstractions;
using ViewModel;

namespace Service;

[Mapper]
public static partial class MessagePayloadMapper
{
    public static partial MessagePayloadViewModel ToViewModel(MessagePayloadModel messagePayloadModel);
}
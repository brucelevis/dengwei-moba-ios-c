# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: TeamProto.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
from google.protobuf import descriptor_pb2
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='TeamProto.proto',
  package='Google.Protobuf',
  syntax='proto3',
  serialized_pb=_b('\n\x0fTeamProto.proto\x12\x0fGoogle.Protobuf\"D\n\x15PB_GamerCreatTeam_C2S\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x10\n\x08targetid\x18\x02 \x01(\r\x12\x0c\n\x04type\x18\x03 \x01(\r\"5\n\x15PB_GamerCreatTeam_S2C\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x0f\n\x07team_id\x18\x02 \x01(\r\"4\n\x14PB_GamerJoinTeam_C2S\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x0f\n\x07team_id\x18\x02 \x01(\r\"1\n\x11PB_GamerLeave_C2S\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x0f\n\x07team_id\x18\x02 \x01(\r\"<\n\x11PB_TeamMemberInfo\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x0c\n\x04icon\x18\x02 \x01(\r\x12\x0c\n\x04name\x18\x03 \x01(\t\"N\n\x0ePB_ChannelChat\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x12\n\nchannel_id\x18\x02 \x01(\r\x12\r\n\x05sText\x18\x03 \x01(\t\x12\x0c\n\x04time\x18\x04 \x01(\x04\"V\n\x16PB_TeamApplyHandle_C2S\x12\x0b\n\x03gid\x18\x01 \x01(\x04\x12\x0c\n\x04team\x18\x02 \x01(\r\x12\x11\n\tapplicant\x18\x03 \x03(\x04\x12\x0e\n\x06handle\x18\x04 \x03(\r*J\n\x08TeamType\x12\x11\n\rTeamType_NONE\x10\x00\x12\x0c\n\x08Team_One\x10\x01\x12\x0e\n\nTeam_Three\x10\x02\x12\r\n\tTeam_Five\x10\x03\x62\x06proto3')
)

_TEAMTYPE = _descriptor.EnumDescriptor(
  name='TeamType',
  full_name='Google.Protobuf.TeamType',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='TeamType_NONE', index=0, number=0,
      options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Team_One', index=1, number=1,
      options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Team_Three', index=2, number=2,
      options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='Team_Five', index=3, number=3,
      options=None,
      type=None),
  ],
  containing_type=None,
  options=None,
  serialized_start=496,
  serialized_end=570,
)
_sym_db.RegisterEnumDescriptor(_TEAMTYPE)

TeamType = enum_type_wrapper.EnumTypeWrapper(_TEAMTYPE)
TeamType_NONE = 0
Team_One = 1
Team_Three = 2
Team_Five = 3



_PB_GAMERCREATTEAM_C2S = _descriptor.Descriptor(
  name='PB_GamerCreatTeam_C2S',
  full_name='Google.Protobuf.PB_GamerCreatTeam_C2S',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_GamerCreatTeam_C2S.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='targetid', full_name='Google.Protobuf.PB_GamerCreatTeam_C2S.targetid', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='type', full_name='Google.Protobuf.PB_GamerCreatTeam_C2S.type', index=2,
      number=3, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=36,
  serialized_end=104,
)


_PB_GAMERCREATTEAM_S2C = _descriptor.Descriptor(
  name='PB_GamerCreatTeam_S2C',
  full_name='Google.Protobuf.PB_GamerCreatTeam_S2C',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_GamerCreatTeam_S2C.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='team_id', full_name='Google.Protobuf.PB_GamerCreatTeam_S2C.team_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=106,
  serialized_end=159,
)


_PB_GAMERJOINTEAM_C2S = _descriptor.Descriptor(
  name='PB_GamerJoinTeam_C2S',
  full_name='Google.Protobuf.PB_GamerJoinTeam_C2S',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_GamerJoinTeam_C2S.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='team_id', full_name='Google.Protobuf.PB_GamerJoinTeam_C2S.team_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=161,
  serialized_end=213,
)


_PB_GAMERLEAVE_C2S = _descriptor.Descriptor(
  name='PB_GamerLeave_C2S',
  full_name='Google.Protobuf.PB_GamerLeave_C2S',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_GamerLeave_C2S.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='team_id', full_name='Google.Protobuf.PB_GamerLeave_C2S.team_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=215,
  serialized_end=264,
)


_PB_TEAMMEMBERINFO = _descriptor.Descriptor(
  name='PB_TeamMemberInfo',
  full_name='Google.Protobuf.PB_TeamMemberInfo',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_TeamMemberInfo.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='icon', full_name='Google.Protobuf.PB_TeamMemberInfo.icon', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='name', full_name='Google.Protobuf.PB_TeamMemberInfo.name', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=266,
  serialized_end=326,
)


_PB_CHANNELCHAT = _descriptor.Descriptor(
  name='PB_ChannelChat',
  full_name='Google.Protobuf.PB_ChannelChat',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_ChannelChat.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='channel_id', full_name='Google.Protobuf.PB_ChannelChat.channel_id', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='sText', full_name='Google.Protobuf.PB_ChannelChat.sText', index=2,
      number=3, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='time', full_name='Google.Protobuf.PB_ChannelChat.time', index=3,
      number=4, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=328,
  serialized_end=406,
)


_PB_TEAMAPPLYHANDLE_C2S = _descriptor.Descriptor(
  name='PB_TeamApplyHandle_C2S',
  full_name='Google.Protobuf.PB_TeamApplyHandle_C2S',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='gid', full_name='Google.Protobuf.PB_TeamApplyHandle_C2S.gid', index=0,
      number=1, type=4, cpp_type=4, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='team', full_name='Google.Protobuf.PB_TeamApplyHandle_C2S.team', index=1,
      number=2, type=13, cpp_type=3, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='applicant', full_name='Google.Protobuf.PB_TeamApplyHandle_C2S.applicant', index=2,
      number=3, type=4, cpp_type=4, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='handle', full_name='Google.Protobuf.PB_TeamApplyHandle_C2S.handle', index=3,
      number=4, type=13, cpp_type=3, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=408,
  serialized_end=494,
)

DESCRIPTOR.message_types_by_name['PB_GamerCreatTeam_C2S'] = _PB_GAMERCREATTEAM_C2S
DESCRIPTOR.message_types_by_name['PB_GamerCreatTeam_S2C'] = _PB_GAMERCREATTEAM_S2C
DESCRIPTOR.message_types_by_name['PB_GamerJoinTeam_C2S'] = _PB_GAMERJOINTEAM_C2S
DESCRIPTOR.message_types_by_name['PB_GamerLeave_C2S'] = _PB_GAMERLEAVE_C2S
DESCRIPTOR.message_types_by_name['PB_TeamMemberInfo'] = _PB_TEAMMEMBERINFO
DESCRIPTOR.message_types_by_name['PB_ChannelChat'] = _PB_CHANNELCHAT
DESCRIPTOR.message_types_by_name['PB_TeamApplyHandle_C2S'] = _PB_TEAMAPPLYHANDLE_C2S
DESCRIPTOR.enum_types_by_name['TeamType'] = _TEAMTYPE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

PB_GamerCreatTeam_C2S = _reflection.GeneratedProtocolMessageType('PB_GamerCreatTeam_C2S', (_message.Message,), dict(
  DESCRIPTOR = _PB_GAMERCREATTEAM_C2S,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_GamerCreatTeam_C2S)
  ))
_sym_db.RegisterMessage(PB_GamerCreatTeam_C2S)

PB_GamerCreatTeam_S2C = _reflection.GeneratedProtocolMessageType('PB_GamerCreatTeam_S2C', (_message.Message,), dict(
  DESCRIPTOR = _PB_GAMERCREATTEAM_S2C,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_GamerCreatTeam_S2C)
  ))
_sym_db.RegisterMessage(PB_GamerCreatTeam_S2C)

PB_GamerJoinTeam_C2S = _reflection.GeneratedProtocolMessageType('PB_GamerJoinTeam_C2S', (_message.Message,), dict(
  DESCRIPTOR = _PB_GAMERJOINTEAM_C2S,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_GamerJoinTeam_C2S)
  ))
_sym_db.RegisterMessage(PB_GamerJoinTeam_C2S)

PB_GamerLeave_C2S = _reflection.GeneratedProtocolMessageType('PB_GamerLeave_C2S', (_message.Message,), dict(
  DESCRIPTOR = _PB_GAMERLEAVE_C2S,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_GamerLeave_C2S)
  ))
_sym_db.RegisterMessage(PB_GamerLeave_C2S)

PB_TeamMemberInfo = _reflection.GeneratedProtocolMessageType('PB_TeamMemberInfo', (_message.Message,), dict(
  DESCRIPTOR = _PB_TEAMMEMBERINFO,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_TeamMemberInfo)
  ))
_sym_db.RegisterMessage(PB_TeamMemberInfo)

PB_ChannelChat = _reflection.GeneratedProtocolMessageType('PB_ChannelChat', (_message.Message,), dict(
  DESCRIPTOR = _PB_CHANNELCHAT,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_ChannelChat)
  ))
_sym_db.RegisterMessage(PB_ChannelChat)

PB_TeamApplyHandle_C2S = _reflection.GeneratedProtocolMessageType('PB_TeamApplyHandle_C2S', (_message.Message,), dict(
  DESCRIPTOR = _PB_TEAMAPPLYHANDLE_C2S,
  __module__ = 'TeamProto_pb2'
  # @@protoc_insertion_point(class_scope:Google.Protobuf.PB_TeamApplyHandle_C2S)
  ))
_sym_db.RegisterMessage(PB_TeamApplyHandle_C2S)


# @@protoc_insertion_point(module_scope)

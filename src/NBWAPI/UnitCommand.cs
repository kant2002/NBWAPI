using System;

namespace NBWAPI
{
    public sealed class UnitCommand : IEquatable<UnitCommand>
    {
        internal Unit _unit;
        internal UnitCommandType _type;
        internal Unit _target;
        internal int _x = Position.None.x;
        internal int _y = Position.None.y;
        internal int _extra = 0;

        private UnitCommand(Unit unit, UnitCommandType type)
        {
            _unit = unit;
            _type = type;
        }

        public static UnitCommand Attack(Unit unit, Position target)
        {
            return Attack(unit, target, false);
        }

        public static UnitCommand Attack(Unit unit, Unit target)
        {
            return Attack(unit, target, false);
        }

        public static UnitCommand Attack(Unit unit, Position target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Attack_Move)
            {
                _x = target.x,
                _y = target.y,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Attack(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Attack_Unit)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Build(Unit unit, TilePosition target, UnitType type)
        {
            return new UnitCommand(unit, UnitCommandType.Build)
            {
                _x = target.x,
                _y = target.y,
                _extra = (int)type
            };
        }

        public static UnitCommand BuildAddon(Unit unit, UnitType type)
        {
            return new UnitCommand(unit, UnitCommandType.Build_Addon)
            {
                _extra = (int)type
            };
        }

        public static UnitCommand Train(Unit unit, UnitType type)
        {
            return new UnitCommand(unit, UnitCommandType.Train)
            {
                _extra = (int)type
            };
        }

        public static UnitCommand Morph(Unit unit, UnitType type)
        {
            return new UnitCommand(unit, UnitCommandType.Morph)
            {
                _extra = (int)type
            };
        }

        public static UnitCommand Research(Unit unit, TechType tech)
        {
            return new UnitCommand(unit, UnitCommandType.Research)
            {
                _extra = (int)tech
            };
        }

        public static UnitCommand Upgrade(Unit unit, UpgradeType upgrade)
        {
            return new UnitCommand(unit, UnitCommandType.Upgrade)
            {
                _extra = (int)upgrade
            };
        }

        public static UnitCommand SetRallyPoint(Unit unit, Position target)
        {
            return new UnitCommand(unit, UnitCommandType.Set_Rally_Position)
            {
                _x = target.x,
                _y = target.y
            };
        }

        public static UnitCommand SetRallyPoint(Unit unit, Unit target)
        {
            return new UnitCommand(unit, UnitCommandType.Set_Rally_Unit)
            {
                _target = target
            };
        }

        public static UnitCommand Move(Unit unit, Position target)
        {
            return Move(unit, target, false);
        }

        public static UnitCommand Move(Unit unit, Position target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Move)
            {
                _x = target.x,
                _y = target.y,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Patrol(Unit unit, Position target)
        {
            return Patrol(unit, target, false);
        }

        public static UnitCommand Patrol(Unit unit, Position target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Patrol)
            {
                _x = target.x,
                _y = target.y,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand HoldPosition(Unit unit)
        {
            return HoldPosition(unit, false);
        }

        public static UnitCommand HoldPosition(Unit unit, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Hold_Position)
            {
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Stop(Unit unit)
        {
            return Stop(unit, false);
        }

        public static UnitCommand Stop(Unit unit, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Stop)
            {
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Follow(Unit unit, Unit target)
        {
            return Follow(unit, target, false);
        }

        public static UnitCommand Follow(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Follow)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Gather(Unit unit, Unit target)
        {
            return Gather(unit, target, false);
        }

        public static UnitCommand Gather(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Gather)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand ReturnCargo(Unit unit)
        {
            return ReturnCargo(unit, false);
        }

        public static UnitCommand ReturnCargo(Unit unit, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Return_Cargo)
            {
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Repair(Unit unit, Unit target)
        {
            return Repair(unit, target, false);
        }

        public static UnitCommand Repair(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Repair)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Burrow(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Burrow);
        }

        public static UnitCommand Unburrow(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Unburrow);
        }

        public static UnitCommand Cloak(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cloak);
        }

        public static UnitCommand Decloak(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Decloak);
        }

        public static UnitCommand Siege(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Siege);
        }

        public static UnitCommand Unsiege(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Unsiege);
        }

        public static UnitCommand Lift(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Lift);
        }

        public static UnitCommand Land(Unit unit, TilePosition target)
        {
            return new UnitCommand(unit, UnitCommandType.Land)
            {
                _x = target.x,
                _y = target.y
            };
        }

        public static UnitCommand Load(Unit unit, Unit target)
        {
            return Load(unit, target, false);
        }

        public static UnitCommand Load(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Load)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand Unload(Unit unit, Unit target)
        {
            return new UnitCommand(unit, UnitCommandType.Unload)
            {
                _target = target
            };
        }

        public static UnitCommand UnloadAll(Unit unit)
        {
            return UnloadAll(unit, false);
        }

        public static UnitCommand UnloadAll(Unit unit, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Unload_All)
            {
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand UnloadAll(Unit unit, Position target)
        {
            return UnloadAll(unit, target, false);
        }

        public static UnitCommand UnloadAll(Unit unit, Position target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Unload_All_Position)
            {
                _x = target.x,
                _y = target.y,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand RightClick(Unit unit, Position target)
        {
            return RightClick(unit, target, false);
        }

        public static UnitCommand RightClick(Unit unit, Unit target)
        {
            return RightClick(unit, target, false);
        }

        public static UnitCommand RightClick(Unit unit, Position target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Right_Click_Position)
            {
                _x = target.x,
                _y = target.y,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand RightClick(Unit unit, Unit target, bool shiftQueueCommand)
        {
            return new UnitCommand(unit, UnitCommandType.Right_Click_Unit)
            {
                _target = target,
                _extra = shiftQueueCommand ? 1 : 0
            };
        }

        public static UnitCommand HaltConstruction(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Halt_Construction);
        }

        public static UnitCommand CancelConstruction(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cancel_Construction);
        }

        public static UnitCommand CancelAddon(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cancel_Addon);
        }

        public static UnitCommand CancelTrain(Unit unit)
        {
            return CancelTrain(unit, -2);
        }

        public static UnitCommand CancelTrain(Unit unit, int slot)
        {
            return new UnitCommand(unit, slot >= 0 ? UnitCommandType.Cancel_Train_Slot : UnitCommandType.Cancel_Train)
            {
                _extra = slot
            };
        }

        public static UnitCommand CancelMorph(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cancel_Morph);
        }

        public static UnitCommand CancelResearch(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cancel_Research);
        }

        public static UnitCommand CancelUpgrade(Unit unit)
        {
            return new UnitCommand(unit, UnitCommandType.Cancel_Upgrade);
        }

        public static UnitCommand UseTech(Unit unit, TechType tech)
        {
            return new UnitCommand(unit, UnitCommandType.Use_Tech)
            {
                _extra = (int)tech,
                _type = tech switch
                {
                    TechType.Burrowing => unit.IsBurrowed() ? UnitCommandType.Unburrow : UnitCommandType.Burrow,
                    TechType.Cloaking_Field => unit.IsCloaked() ? UnitCommandType.Decloak : UnitCommandType.Cloak,
                    TechType.Personnel_Cloaking => unit.IsCloaked() ? UnitCommandType.Decloak : UnitCommandType.Cloak,
                    TechType.Tank_Siege_Mode => unit.IsSieged() ? UnitCommandType.Unsiege : UnitCommandType.Siege,
                    _ => UnitCommandType.None,
                }
            };
        }

        public static UnitCommand UseTech(Unit unit, TechType tech, Position target)
        {
            return new UnitCommand(unit, UnitCommandType.Use_Tech_Position)
            {
                _x = target.x,
                _y = target.y,
                _extra = (int)tech
            };
        }

        public static UnitCommand UseTech(Unit unit, TechType tech, Unit target)
        {
            return new UnitCommand(unit, UnitCommandType.Use_Tech_Unit)
            {
                _target = target,
                _extra = (int)tech
            };
        }

        public static UnitCommand PlaceCOP(Unit unit, TilePosition target)
        {
            return new UnitCommand(unit, UnitCommandType.Place_COP)
            {
                _x = target.x,
                _y = target.y
            };
        }

        public Unit GetUnit()
        {
            return _unit;
        }

        public UnitCommandType GetUnitCommandType()
        {
            return _type;
        }

        public Unit GetTarget()
        {
            return _target;
        }

        public int GetSlot()
        {
            return _type == UnitCommandType.Cancel_Train_Slot ? _extra : -1;
        }

        public Position GetTargetPosition()
        {
            if (_type == UnitCommandType.Build || _type == UnitCommandType.Land || _type == UnitCommandType.Place_COP)
            {
                return new TilePosition(_x, _y).ToPosition();
            }

            return new Position(_x, _y);
        }

        public TilePosition GetTargetTilePosition()
        {
            if (_type == UnitCommandType.Build || _type == UnitCommandType.Land || _type == UnitCommandType.Place_COP)
            {
                return new TilePosition(_x, _y);
            }

            return new Position(_x, _y).ToTilePosition();
        }

        public UnitType GetUnitType()
        {
            if (_type == UnitCommandType.Build || _type == UnitCommandType.Build_Addon || _type == UnitCommandType.Train || _type == UnitCommandType.Morph)
            {
                return (UnitType)_extra;
            }

            return UnitType.None;
        }

        public TechType GetTechType()
        {
            if (_type == UnitCommandType.Research || _type == UnitCommandType.Use_Tech || _type == UnitCommandType.Use_Tech_Position || _type == UnitCommandType.Use_Tech_Unit)
            {
                return (TechType)_extra;
            }

            return TechType.None;
        }

        public UpgradeType GetUpgradeType()
        {
            return _type == UnitCommandType.Upgrade ? (UpgradeType)_extra : UpgradeType.None;
        }

        public bool IsQueued()
        {
            return (_type == UnitCommandType.Attack_Move || _type == UnitCommandType.Attack_Unit || _type == UnitCommandType.Move || _type == UnitCommandType.Patrol || _type == UnitCommandType.Hold_Position || _type == UnitCommandType.Stop || _type == UnitCommandType.Follow || _type == UnitCommandType.Gather || _type == UnitCommandType.Return_Cargo || _type == UnitCommandType.Load || _type == UnitCommandType.Unload_All || _type == UnitCommandType.Unload_All_Position || _type == UnitCommandType.Right_Click_Position || _type == UnitCommandType.Right_Click_Unit) && _extra != 0;
        }

        public bool Equals(UnitCommand other)
        {
            return _x == other._x && _y == other._y && _extra == other._extra && _type == other._type && object.Equals(_target, other._target) && object.Equals(_unit, other._unit);
        }

        public override bool Equals(object o)
        {
            return o is UnitCommand other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_type, _target, _x, _y, _extra, _unit);
        }
    }
}
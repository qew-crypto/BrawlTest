using BSL.v59.TitanEngine.DataS.HelpsLogic;

namespace BSL.v59.Logic.Protocol.Laser.S;

public class OwnHomeDataMessage : PiranhaMessage
{
    private static readonly int[] BrawlerIds =
    [
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,
        18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 34, 35,
        36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52,
        53, 54, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
        71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87
    ];

    private static readonly int[] UnlockCardIds =
    [
        0, 4, 8, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64,
        68, 72, 95, 100, 105, 110, 115, 120, 125, 130, 177, 182, 188, 194,
        200, 206, 218, 224, 230, 236, 279, 296, 303, 320, 327, 334, 341, 358,
        365, 372, 379, 386, 393, 410, 417, 427, 434, 448, 466, 474, 491, 499,
        507, 515, 523, 531, 539, 547, 557, 565, 573, 581, 589, 597, 605, 619,
        633, 642, 655, 663, 671, 730, 748, 760, 768, 800, 811, 828, 844
    ];

    public override void Encode()
    {
        base.Encode();
        
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(-1);
        
        // LogicClientHome start
        // LogicDailyData start
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStreamHelper.WriteDataReference(ByteStream, 28, 677);
        ByteStreamHelper.WriteDataReference(ByteStream, 43, 0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(1);
        ByteStream.WriteBoolean(true);
        ByteStream.WriteVInt(19500);
        ByteStream.WriteVInt(111111);
        ByteStream.WriteVInt(1375134);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(1375134);
        
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteBoolean(true);
        ByteStream.WriteVInt(2);
        ByteStream.WriteVInt(2);
        ByteStream.WriteVInt(2);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0); // shop offers
        
        ByteStream.WriteVInt(200);
        ByteStream.WriteVInt(-1);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(-1);
        
        ByteStream.WriteByte(1);
        {
            ByteStreamHelper.WriteDataReference(ByteStream, 16, 0);
        }

        ByteStream.WriteString("RU");
        ByteStream.WriteString("BSL.v59");

        ByteStream.WriteVInt(8);
        {
            ByteStream.WriteVLong(new LogicLong(1, 9));
            ByteStream.WriteVLong(new LogicLong(1, 22));
            ByteStream.WriteVLong(new LogicLong(3, 25));
            ByteStream.WriteVLong(new LogicLong(1, 24));
            ByteStream.WriteVLong(new LogicLong(2, 15));
            ByteStream.WriteVLong(new LogicLong(9889434, 28));
            ByteStream.WriteVLong(new LogicLong(100, 46));    
            ByteStream.WriteVLong(new LogicLong(1, 52)); 
        }
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(1);
        {
            ByteStream.WriteVInt(34);
            ByteStream.WriteVInt(0);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteVInt(0);

            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(true);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);

            ByteStream.WriteBoolean(true);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);

            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(true);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
            ByteStream.WriteInt(0);
        }
        
        if (ByteStream.WriteBoolean(true))
        {
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
        }
        
        if (ByteStream.WriteBoolean(true))
            ByteStream.WriteVInt(0);
        
        ByteStream.WriteBoolean(false);

        ByteStream.WriteInt(0);
        ByteStream.WriteVInt(0);
        ByteStreamHelper.WriteDataReference(ByteStream, 16, 0);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteVInt(-1);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);

        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        
        // LogicDailyData end
        
        // LogicConfData start
        
        ByteStream.WriteVInt(-1);
        
        var es = ByteStream.WriteVInt(38);
        for (var i = 0; i < es; i++)
            ByteStream.WriteVInt(i + 1);

        ByteStream.WriteVInt(1);
        {
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(1);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(85926);
            ByteStream.WriteVInt(5);
            ByteStreamHelper.WriteDataReference(ByteStream, 15, 13);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(0);
            ByteStream.WriteString(null);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteVInt(0);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false);
            ByteStream.WriteBoolean(false); 
        }
        
        ByteStream.WriteVInt(0);

        ByteStream.WriteVInt(10);
        foreach (var i in new []{20, 35, 75, 140, 290, 480, 800, 1250, 1875, 2800})
            ByteStream.WriteVInt(i);
        
        ByteStream.WriteVInt(4);
        foreach (var i in new []{30, 80, 170, 360})
            ByteStream.WriteVInt(i);
        
        ByteStream.WriteVInt(4);
        foreach (var i in new []{300, 880, 2040, 4680})
            ByteStream.WriteVInt(i);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(21);
        {
            ByteStream.WriteVLong(new LogicLong(501, 10008));
            ByteStream.WriteVLong(new LogicLong(0, 10046));
            ByteStream.WriteVLong(new LogicLong(30, 10050));
            ByteStream.WriteVLong(new LogicLong(0, 10051));
            ByteStream.WriteVLong(new LogicLong(5600, 10060));
            ByteStream.WriteVLong(new LogicLong(200, 117));
            ByteStream.WriteVLong(new LogicLong(1, 128));
            ByteStream.WriteVLong(new LogicLong(0, 65));
            ByteStream.WriteVLong(new LogicLong(41000000 + 117, 1));
            ByteStream.WriteVLong(new LogicLong(99999999, 131));
            ByteStream.WriteVLong(new LogicLong(100000, 138));
            ByteStream.WriteVLong(new LogicLong(1, 95));
            ByteStream.WriteVLong(new LogicLong(55598, 47));
            ByteStream.WriteVLong(new LogicLong(1, 123));
            ByteStream.WriteVLong(new LogicLong(200, 124));
            ByteStream.WriteVLong(new LogicLong(55598, 48));
            ByteStream.WriteVLong(new LogicLong(3, 50));
            ByteStream.WriteVLong(new LogicLong(500, 1100));
            ByteStream.WriteVLong(new LogicLong(500, 1101));
            ByteStream.WriteVLong(new LogicLong(1, 1002));
            ByteStream.WriteVLong(new LogicLong(500, 1102));
        }

        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(0);

        ByteStream.WriteVInt(6);
        foreach (var i in new []{0, 29, 79, 169, 349, 699})
            ByteStream.WriteVInt(i);
        
        ByteStream.WriteVInt(6);
        foreach (var i in new []{0, 160, 450, 500, 1250, 2500})
            ByteStream.WriteVInt(i);
        
        ByteStream.WriteVInt(5);
        foreach (var i in new []{0, 100, 400, 1000, 3000})
            ByteStream.WriteVInt(i);
        
        // LogicConfData end

        new LogicLong(0, 1).Encode(ByteStream);
        
        ByteStream.WriteVInt(0);
        
        ByteStream.WriteVInt(-1);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);

        ByteStream.WriteBoolean(false);

        ByteStream.WriteBoolean(false);

        ByteStream.WriteBoolean(false);

        ByteStream.WriteVInt(0);

        ByteStream.WriteBoolean(true); 
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(1);
        {
            ByteStreamHelper.WriteDataReference(ByteStream, 16, 90);
            ByteStream.WriteVInt(1900);
            ByteStream.WriteVInt(349);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);
        }
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);

        ByteStream.WriteVInt(0);

        ByteStreamHelper.WriteDataReference(ByteStream, 0);
        ByteStreamHelper.WriteDataReference(ByteStream, 0);
        ByteStreamHelper.WriteDataReference(ByteStream, 0);
        ByteStreamHelper.WriteDataReference(ByteStream, 0);
        ByteStreamHelper.WriteDataReference(ByteStream, 0);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteBoolean(false);

        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteInt(-1488);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(51998);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteBoolean(false);
        
        ByteStream.WriteBoolean(false);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteBoolean(false);
        ByteStream.WriteVInt(2);
        ByteStreamHelper.WriteDataReference(ByteStream, 95, 0);
        ByteStream.WriteVInt(1);
        ByteStreamHelper.WriteDataReference(ByteStream, 95, 1);
        ByteStream.WriteVInt(1);
        ByteStream.WriteBoolean(false);
        
        // LogicClientHome end
        
        // LogicClientAvatar start
        
        ByteStreamHelper.EncodeLogicLong(ByteStream, 1);
        ByteStreamHelper.EncodeLogicLong(ByteStream, 1);
        ByteStreamHelper.EncodeLogicLong(ByteStream, 0);

        ByteStream.WriteStringReference("MeshBrawl");
        ByteStream.WriteBoolean(true);
        ByteStream.WriteInt(-1);
        
        ByteStream.WriteVInt(23);
        {
            ByteStream.WriteVInt(UnlockCardIds.Length + 2);
            foreach (var cardId in UnlockCardIds)
            {
                ByteStreamHelper.WriteDataReference(ByteStream, 23, cardId);
                ByteStream.WriteVInt(-1);
                ByteStream.WriteVInt(1);
            }

            // Coins and bling.
            ByteStreamHelper.WriteDataReference(ByteStream, 5, 8);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(100000);
            ByteStreamHelper.WriteDataReference(ByteStream, 5, 23);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(10000);

            WriteBrawlerValues(0); // Trophies
            WriteBrawlerValues(0); // Highest trophies

            ByteStream.WriteVInt(0);
            ByteStream.WriteVInt(0);

            WriteBrawlerValues(10); // Power level 11

            ByteStream.WriteVInt(0);
            WriteBrawlerValues(2); // Seen/unlocked state

            for (var i = 0; i < 15; i++)
                ByteStream.WriteVInt(0);
        }
        
        ByteStream.WriteVInt(1000);
        ByteStream.WriteVInt(1000);
        ByteStream.WriteVInt(1);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(2);
        ByteStream.WriteVInt(1);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteString(null);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(0);
        ByteStream.WriteVInt(2);
    }

    private void WriteBrawlerValues(int value)
    {
        ByteStream.WriteVInt(BrawlerIds.Length);
        foreach (var brawlerId in BrawlerIds)
        {
            ByteStreamHelper.WriteDataReference(ByteStream, 16, brawlerId);
            ByteStream.WriteVInt(-1);
            ByteStream.WriteVInt(value);
        }
    }

    public override int GetMessageType()
    {
        return 24101;
    }

    public override int GetServiceNodeType()
    {
        return 9;
    }
}
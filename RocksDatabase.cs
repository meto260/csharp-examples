public class RocksDatabase {
    string path= Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    RocksDb db;
    public RocksDatabase() {
        var options = new DbOptions()
            .SetCreateIfMissing(true)
            .IncreaseParallelism(10)
            .PrepareForBulkLoad()
            .SetAllowConcurrentMemtableWrite(true)
            .SkipStatsUpdateOnOpen(true)
            .SetUseDirectReads(true)
            .EnableStatistics();
        db = RocksDb.Open(options, path);
    }

    public void Put(string key, string value) {
        db.Put(key, value);
        db.Dispose();
    }


    public void Get(string key, string value) {
        db.Get(key);
        db.Dispose();
    }

    public void Remove(string key, string value) {
        db.Remove(key);
        db.Dispose();
    }
}
